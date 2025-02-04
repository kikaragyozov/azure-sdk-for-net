// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

namespace Azure.ResourceManager.ApiManagement.Models
{
    /// <summary> API Management service resource SKU properties. </summary>
    public partial class ApiManagementServiceSkuProperties
    {
        /// <summary> Initializes a new instance of ApiManagementServiceSkuProperties. </summary>
        /// <param name="name"> Name of the Sku. </param>
        /// <param name="capacity"> Capacity of the SKU (number of deployed units of the SKU). For Consumption SKU capacity must be specified as 0. </param>
        public ApiManagementServiceSkuProperties(ApiManagementServiceSkuType name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }

        /// <summary> Name of the Sku. </summary>
        public ApiManagementServiceSkuType Name { get; set; }
        /// <summary> Capacity of the SKU (number of deployed units of the SKU). For Consumption SKU capacity must be specified as 0. </summary>
        public int Capacity { get; set; }
    }
}
