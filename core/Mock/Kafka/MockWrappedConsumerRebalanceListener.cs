﻿using Confluent.Kafka;
using Kafka.Streams.Net.Kafka;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kafka.Streams.Net.Mock.Kafka
{
    internal class MockWrappedConsumerRebalanceListener : IConsumerRebalanceListener
    {
        private readonly IConsumerRebalanceListener wrapped;
        private readonly MockConsumer consumer;

        public MockWrappedConsumerRebalanceListener(IConsumerRebalanceListener wrapped, MockConsumer consumer)
        {
            this.wrapped = wrapped;
            this.consumer = consumer;
        }

        public void PartitionsAssigned(IConsumer<byte[], byte[]> consumer, List<TopicPartition> partitions)
        {
            this.consumer.PartitionsAssigned(partitions);
            wrapped?.PartitionsAssigned(consumer, partitions);
        }

        public void PartitionsRevoked(IConsumer<byte[], byte[]> consumer, List<TopicPartitionOffset> partitions)
        {
            this.consumer.PartitionsRevoked(partitions);
            wrapped?.PartitionsRevoked(consumer, partitions);
        }
    }
}