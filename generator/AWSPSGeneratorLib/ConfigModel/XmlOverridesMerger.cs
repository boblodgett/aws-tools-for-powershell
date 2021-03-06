﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace AWSPowerShellGenerator.ServiceConfig
{
    class XmlOverridesMerger
    {
        public static void ApplyOverrides(string folderPath, ConfigModelCollection modelCollection, string configurationsFolder)
        {
            var serviceOverrides = DeserializeModelCollection(folderPath);

            foreach (var serviceOverride in serviceOverrides)
            {
                ConfigModel configModel;
                if (modelCollection.ConfigModels.TryGetValue(serviceOverride.C2jFilename, out configModel))
                {
                    configModel = Merge(configModel, serviceOverride);
                    modelCollection.ConfigModels[configModel.C2jFilename] = configModel;
                }
                else
                {
                    configModel = serviceOverride;
                    configModel.ModelFilename = configModel.C2jFilename + ".xml";
                    modelCollection.ConfigModels.Add(serviceOverride.C2jFilename, serviceOverride);
                }

                configModel.ServiceOperationsList = configModel.ServiceOperationsList.OrderBy(so => so.MethodName).ToList();
                configModel.Serialize(configurationsFolder);
            }
        }

        private static ConfigModel Merge(ConfigModel configModel, ConfigModel serviceOverride)
        {
            //We don't allow to override some of the service configurations!
            if (serviceOverride.AssemblyName != configModel.AssemblyName ||
                serviceOverride.ServiceNounPrefix != configModel.ServiceNounPrefix ||
                serviceOverride.ServiceModuleGuid != configModel.ServiceModuleGuid ||
                serviceOverride.ServiceClientInterface != configModel.ServiceClientInterface ||
                serviceOverride.ServiceClient != configModel.ServiceClient)
            {
                throw new NotSupportedException("The service identification parameters cannot be changed through overrides");
            }

            serviceOverride.ModelFilename = configModel.ModelFilename;

            var modelOperations = configModel.ServiceOperationsList.ToDictionary(a => a.MethodName, a => a);
            foreach (var operationOverride in serviceOverride.ServiceOperationsList)
            {
                if (modelOperations.ContainsKey(operationOverride.MethodName))
                {
                    modelOperations[operationOverride.MethodName] = operationOverride;
                }
                else
                {
                    modelOperations.Add(operationOverride.MethodName, operationOverride);
                }
            }

            serviceOverride.ServiceOperationsList = modelOperations.Values.ToList();

            return serviceOverride;
        }

        private static List<ConfigModel> DeserializeModelCollection(string folderPath)
        {
            var fileName = Path.Combine(folderPath, "overrides.xml");

            if (!File.Exists(fileName))
            {
                return new List<ConfigModel>();
            }

            var schemaFileName = Path.Combine(folderPath, "XmlSchemas", "ConfigurationOverrides", "overrides.xsd");

            try
            {
                var settings = new XmlReaderSettings();
                settings.Schemas.Add(null, schemaFileName);
                settings.ValidationType = ValidationType.Schema;

                var reader = XmlReader.Create(fileName, settings);
                var document = new XmlDocument();
                document.Load(reader);

                var overrides = new XmlAttributeOverrides();
                overrides.Add(typeof(ConfigModel), new XmlAttributes() { XmlRoot = new XmlRootAttribute("Service") });
                var serializer = new XmlSerializer(typeof(ConfigModel), overrides);
                return document.DocumentElement.ChildNodes
                    .OfType<XmlNode>()
                    .Select(node => (ConfigModel)serializer.Deserialize(new XmlNodeReader(node)))
                    .ToList();
            }
            catch (Exception e)
            {
                throw new InvalidDataException("Error deserializing override file", e);
            }
        }
    }
}
