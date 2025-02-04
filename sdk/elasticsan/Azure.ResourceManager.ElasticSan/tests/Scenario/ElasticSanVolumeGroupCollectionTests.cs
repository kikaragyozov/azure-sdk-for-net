﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.ElasticSan.Models;
using Azure.ResourceManager.Resources;
using Microsoft.Identity.Client;
using NUnit.Framework;

namespace Azure.ResourceManager.ElasticSan.Tests.Scenario
{
    public class ElasticSanVolumeGroupCollectionTests : ElasticSanTestBase
    {
        public ElasticSanVolumeGroupCollectionTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [Test]
        [RecordedTest]
        public async Task CreateOrUpdate()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection collection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();

            string volumeGroupName = Recording.GenerateAssetName("testvolumegroup-");
            ElasticSanVolumeGroupData volumeGroupData = new ElasticSanVolumeGroupData()
            {
                ProtocolType = StorageTargetType.Iscsi,
                Encryption = ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey
            };
            volumeGroupData.Tags.Add("tag1", "value1");
            // vnet resource id is created by following instructions in https://docs.microsoft.com/en-us/azure/storage/common/storage-network-security?tabs=azure-portal
            var vnetResourceId = new ResourceIdentifier("/subscriptions/" + DefaultSubscription.Data.Id.Name + "/resourceGroups/" + ResourceGroupName + "/providers/Microsoft.Network/virtualNetworks/testvnet/subnets/subnet1");
            volumeGroupData.VirtualNetworkRules.Add(new ElasticSanVirtualNetworkRule(vnetResourceId));

            ElasticSanVolumeGroupResource volumeGroupResource = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, volumeGroupData)).Value;
            Assert.AreEqual(volumeGroupResource.Id.Name, volumeGroupName);
            Assert.AreEqual(ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey, volumeGroupResource.Data.Encryption);
            Assert.AreEqual(StorageTargetType.Iscsi, volumeGroupResource.Data.ProtocolType);
            Assert.IsTrue(volumeGroupResource.Data.Tags.ContainsKey("tag1"));
            Assert.AreEqual("value1", volumeGroupResource.Data.Tags["tag1"]);
            Assert.GreaterOrEqual(volumeGroupResource.Data.VirtualNetworkRules.Count, 1);
            Assert.AreEqual(vnetResourceId, volumeGroupResource.Data.VirtualNetworkRules[0].VirtualNetworkResourceId);
        }

        [Test]
        [RecordedTest]
        public async Task Get()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection collection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();

            string volumeGroupName = Recording.GenerateAssetName("testvolumegroup-");
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName, new ElasticSanVolumeGroupData())).Value;
            ElasticSanVolumeGroupResource volumeGroup = (await collection.GetAsync(volumeGroupName)).Value;
            Assert.AreEqual(volumeGroup.Id.Name, volumeGroupName);
            Assert.IsEmpty(volumeGroup.Data.Tags);
            Assert.IsEmpty(volumeGroup.Data.VirtualNetworkRules);
            Assert.AreEqual(StorageTargetType.Iscsi, volumeGroup.Data.ProtocolType);
            Assert.AreEqual(ElasticSanEncryptionType.EncryptionAtRestWithPlatformKey, volumeGroup.Data.Encryption);
        }

        [Test]
        [RecordedTest]
        public async Task GetAll()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection collection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();

            string volumeGroupName1 = Recording.GenerateAssetName("testvolumegroup-");
            string volumeGroupName2 = Recording.GenerateAssetName("testvolumegroup-");
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName1, new ElasticSanVolumeGroupData())).Value;
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName2, new ElasticSanVolumeGroupData())).Value;

            int count = 0;
            await foreach (ElasticSanVolumeGroupResource _ in collection.GetAllAsync())
            {
                count++;
            }
            Assert.GreaterOrEqual(count, 2);
        }

        [Test]
        [RecordedTest]
        public async Task Exists()
        {
            ElasticSanCollection elasticSanCollection = (await GetResourceGroupAsync(ResourceGroupName)).GetElasticSans();
            ElasticSanVolumeGroupCollection collection = (await elasticSanCollection.GetAsync(ElasticSanName)).Value.GetElasticSanVolumeGroups();

            string volumeGroupName1 = Recording.GenerateAssetName("testvolumegroup-");
            _ = (await collection.CreateOrUpdateAsync(WaitUntil.Completed, volumeGroupName1, new ElasticSanVolumeGroupData())).Value;
            Assert.IsTrue(await collection.ExistsAsync(volumeGroupName1));
            Assert.IsFalse(await collection.ExistsAsync(volumeGroupName1 + "111"));
        }
    }
}
