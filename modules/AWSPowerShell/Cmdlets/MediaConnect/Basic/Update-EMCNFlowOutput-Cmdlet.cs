/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.MediaConnect;
using Amazon.MediaConnect.Model;

namespace Amazon.PowerShell.Cmdlets.EMCN
{
    /// <summary>
    /// Updates an existing flow output.
    /// </summary>
    [Cmdlet("Update", "EMCNFlowOutput", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.MediaConnect.Model.Output")]
    [AWSCmdlet("Calls the AWS Elemental MediaConnect UpdateFlowOutput API operation.", Operation = new[] {"UpdateFlowOutput"}, SelectReturnType = typeof(Amazon.MediaConnect.Model.UpdateFlowOutputResponse))]
    [AWSCmdletOutput("Amazon.MediaConnect.Model.Output or Amazon.MediaConnect.Model.UpdateFlowOutputResponse",
        "This cmdlet returns an Amazon.MediaConnect.Model.Output object.",
        "The service call response (type Amazon.MediaConnect.Model.UpdateFlowOutputResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class UpdateEMCNFlowOutputCmdlet : AmazonMediaConnectClientCmdlet, IExecutor
    {
        
        #region Parameter CidrAllowList
        /// <summary>
        /// <para>
        /// The range of IP addresses that should be
        /// allowed to initiate output requests to this flow. These IP addresses should be in
        /// the form of a Classless Inter-Domain Routing (CIDR) block; for example, 10.0.0.0/16.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String[] CidrAllowList { get; set; }
        #endregion
        
        #region Parameter Description
        /// <summary>
        /// <para>
        /// A description of the output. This description
        /// appears only on the AWS Elemental MediaConnect console and will not be seen by the
        /// end user.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Description { get; set; }
        #endregion
        
        #region Parameter Destination
        /// <summary>
        /// <para>
        /// The IP address where you want to send the
        /// output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String Destination { get; set; }
        #endregion
        
        #region Parameter Encryption
        /// <summary>
        /// <para>
        /// The type of key used for the encryption. If
        /// no keyType is provided, the service will use the default setting (static-key).
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
        #endregion
        
        #region Parameter FlowArn
        /// <summary>
        /// <para>
        /// The flow that is associated with the output that
        /// you want to update.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String FlowArn { get; set; }
        #endregion
        
        #region Parameter MaxLatency
        /// <summary>
        /// <para>
        /// The maximum latency in milliseconds for Zixi-based
        /// streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? MaxLatency { get; set; }
        #endregion
        
        #region Parameter OutputArn
        /// <summary>
        /// <para>
        /// The ARN of the output that you want to update.
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String OutputArn { get; set; }
        #endregion
        
        #region Parameter Port
        /// <summary>
        /// <para>
        /// The port to use when content is distributed to this
        /// output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? Port { get; set; }
        #endregion
        
        #region Parameter Protocol
        /// <summary>
        /// <para>
        /// The protocol to use for the output.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        [AWSConstantClassSource("Amazon.MediaConnect.Protocol")]
        public Amazon.MediaConnect.Protocol Protocol { get; set; }
        #endregion
        
        #region Parameter RemoteId
        /// <summary>
        /// <para>
        /// The remote ID for the Zixi-pull stream.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String RemoteId { get; set; }
        #endregion
        
        #region Parameter SmoothingLatency
        /// <summary>
        /// <para>
        /// The smoothing latency in milliseconds
        /// for RIST, RTP, and RTP-FEC streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.Int32? SmoothingLatency { get; set; }
        #endregion
        
        #region Parameter StreamId
        /// <summary>
        /// <para>
        /// The stream ID that you want to use for this transport.
        /// This parameter applies only to Zixi-based streams.
        /// </para>
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public System.String StreamId { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'Output'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.MediaConnect.Model.UpdateFlowOutputResponse).
        /// Specifying the name of a property of type Amazon.MediaConnect.Model.UpdateFlowOutputResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "Output";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the OutputArn parameter.
        /// The -PassThru parameter is deprecated, use -Select '^OutputArn' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^OutputArn' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.OutputArn), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Update-EMCNFlowOutput (UpdateFlowOutput)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.MediaConnect.Model.UpdateFlowOutputResponse, UpdateEMCNFlowOutputCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.OutputArn;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (this.CidrAllowList != null)
            {
                context.CidrAllowList = new List<System.String>(this.CidrAllowList);
            }
            context.Description = this.Description;
            context.Destination = this.Destination;
            context.Encryption = this.Encryption;
            context.FlowArn = this.FlowArn;
            #if MODULAR
            if (this.FlowArn == null && ParameterWasBound(nameof(this.FlowArn)))
            {
                WriteWarning("You are passing $null as a value for parameter FlowArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.MaxLatency = this.MaxLatency;
            context.OutputArn = this.OutputArn;
            #if MODULAR
            if (this.OutputArn == null && ParameterWasBound(nameof(this.OutputArn)))
            {
                WriteWarning("You are passing $null as a value for parameter OutputArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.Port = this.Port;
            context.Protocol = this.Protocol;
            context.RemoteId = this.RemoteId;
            context.SmoothingLatency = this.SmoothingLatency;
            context.StreamId = this.StreamId;
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.MediaConnect.Model.UpdateFlowOutputRequest();
            
            if (cmdletContext.CidrAllowList != null)
            {
                request.CidrAllowList = cmdletContext.CidrAllowList;
            }
            if (cmdletContext.Description != null)
            {
                request.Description = cmdletContext.Description;
            }
            if (cmdletContext.Destination != null)
            {
                request.Destination = cmdletContext.Destination;
            }
            if (cmdletContext.Encryption != null)
            {
                request.Encryption = cmdletContext.Encryption;
            }
            if (cmdletContext.FlowArn != null)
            {
                request.FlowArn = cmdletContext.FlowArn;
            }
            if (cmdletContext.MaxLatency != null)
            {
                request.MaxLatency = cmdletContext.MaxLatency.Value;
            }
            if (cmdletContext.OutputArn != null)
            {
                request.OutputArn = cmdletContext.OutputArn;
            }
            if (cmdletContext.Port != null)
            {
                request.Port = cmdletContext.Port.Value;
            }
            if (cmdletContext.Protocol != null)
            {
                request.Protocol = cmdletContext.Protocol;
            }
            if (cmdletContext.RemoteId != null)
            {
                request.RemoteId = cmdletContext.RemoteId;
            }
            if (cmdletContext.SmoothingLatency != null)
            {
                request.SmoothingLatency = cmdletContext.SmoothingLatency.Value;
            }
            if (cmdletContext.StreamId != null)
            {
                request.StreamId = cmdletContext.StreamId;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.MediaConnect.Model.UpdateFlowOutputResponse CallAWSServiceOperation(IAmazonMediaConnect client, Amazon.MediaConnect.Model.UpdateFlowOutputRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "AWS Elemental MediaConnect", "UpdateFlowOutput");
            try
            {
                #if DESKTOP
                return client.UpdateFlowOutput(request);
                #elif CORECLR
                return client.UpdateFlowOutputAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public List<System.String> CidrAllowList { get; set; }
            public System.String Description { get; set; }
            public System.String Destination { get; set; }
            public Amazon.MediaConnect.Model.UpdateEncryption Encryption { get; set; }
            public System.String FlowArn { get; set; }
            public System.Int32? MaxLatency { get; set; }
            public System.String OutputArn { get; set; }
            public System.Int32? Port { get; set; }
            public Amazon.MediaConnect.Protocol Protocol { get; set; }
            public System.String RemoteId { get; set; }
            public System.Int32? SmoothingLatency { get; set; }
            public System.String StreamId { get; set; }
            public System.Func<Amazon.MediaConnect.Model.UpdateFlowOutputResponse, UpdateEMCNFlowOutputCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.Output;
        }
        
    }
}