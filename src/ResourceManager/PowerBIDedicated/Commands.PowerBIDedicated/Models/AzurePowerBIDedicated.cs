﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;
using Microsoft.Azure.Management.PowerBIDedicated.Models;
using System.Collections.Generic;

namespace Microsoft.Azure.Commands.PowerBIDedicated.Models
{
    public class AzurePowerBIDedicated
    {
        public List<string> Administrator { get; set; }

        public string State { get; private set; }

        public string ProvisioningState { get; private set; }

        public string Id { get; private set; }

        public string Name { get; set; }

        public string Type { get; private set; }

        public string Location { get; set; }

        public string Sku { get; set; }

        public string Tier { get; set; }

        public System.Collections.Generic.IDictionary<string, string> Tag { get; set; }

        internal static AzurePowerBIDedicatedDetail FromPowerBIDedicated(DedicatedCapacity capacity)
        {
            if (capacity == null)
            {
                return null;
            }

            return new AzurePowerBIDedicatedDetail()
            {
                Administrator = capacity.Administration == null
                    ? new List<string>()
                    : new List<string>(capacity.Administration.Members),
                Location = capacity.Location,
                Name = capacity.Name,
                Type = capacity.Type,
                State = capacity.State,
                ProvisioningState = capacity.ProvisioningState,
                Id = capacity.Id,
                Sku = capacity.Sku.Name,
                Tier = capacity.Sku.Tier,
                Tag = capacity.Tags != null ? new Dictionary<string, string>(capacity.Tags) : new Dictionary<string, string>(),
            };
        }

        internal static List<AzurePowerBIDedicatedDetail> FromPowerBIDedicatedCollection(List<DedicatedCapacity> list)
        {
            if (list == null)
            {
                return null;
            }

            var listAzurePowerBIDedicated = new List<AzurePowerBIDedicatedDetail>();
            list.ForEach(capacity => listAzurePowerBIDedicated.Add(FromPowerBIDedicated(capacity)));
            return listAzurePowerBIDedicated;
        }
    }

    public class AzurePowerBIDedicatedDetail : AzurePowerBIDedicated
    {
    //    public new System.Collections.Generic.IDictionary<string, string> Sku { get; set; }
    }
}
