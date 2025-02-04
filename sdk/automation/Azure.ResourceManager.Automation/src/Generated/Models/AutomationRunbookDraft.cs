// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using Azure.Core;

namespace Azure.ResourceManager.Automation.Models
{
    /// <summary> The AutomationRunbookDraft. </summary>
    public partial class AutomationRunbookDraft
    {
        /// <summary> Initializes a new instance of AutomationRunbookDraft. </summary>
        public AutomationRunbookDraft()
        {
            Parameters = new ChangeTrackingDictionary<string, RunbookParameterDefinition>();
            OutputTypes = new ChangeTrackingList<string>();
        }

        /// <summary> Initializes a new instance of AutomationRunbookDraft. </summary>
        /// <param name="isInEditMode"> Gets or sets whether runbook is in edit mode. </param>
        /// <param name="draftContentLink"> Gets or sets the draft runbook content link. </param>
        /// <param name="createdOn"> Gets or sets the creation time of the runbook draft. </param>
        /// <param name="lastModifiedOn"> Gets or sets the last modified time of the runbook draft. </param>
        /// <param name="parameters"> Gets or sets the runbook draft parameters. </param>
        /// <param name="outputTypes"> Gets or sets the runbook output types. </param>
        internal AutomationRunbookDraft(bool? isInEditMode, AutomationContentLink draftContentLink, DateTimeOffset? createdOn, DateTimeOffset? lastModifiedOn, IDictionary<string, RunbookParameterDefinition> parameters, IList<string> outputTypes)
        {
            IsInEditMode = isInEditMode;
            DraftContentLink = draftContentLink;
            CreatedOn = createdOn;
            LastModifiedOn = lastModifiedOn;
            Parameters = parameters;
            OutputTypes = outputTypes;
        }

        /// <summary> Gets or sets whether runbook is in edit mode. </summary>
        public bool? IsInEditMode { get; set; }
        /// <summary> Gets or sets the draft runbook content link. </summary>
        public AutomationContentLink DraftContentLink { get; set; }
        /// <summary> Gets or sets the creation time of the runbook draft. </summary>
        public DateTimeOffset? CreatedOn { get; set; }
        /// <summary> Gets or sets the last modified time of the runbook draft. </summary>
        public DateTimeOffset? LastModifiedOn { get; set; }
        /// <summary> Gets or sets the runbook draft parameters. </summary>
        public IDictionary<string, RunbookParameterDefinition> Parameters { get; }
        /// <summary> Gets or sets the runbook output types. </summary>
        public IList<string> OutputTypes { get; }
    }
}
