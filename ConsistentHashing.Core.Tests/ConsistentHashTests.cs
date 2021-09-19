using ConsistentHashing.Core.Storage;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ConsistentHashing.Core.Tests
{
    public class ConsistentHashTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetNode_ReturnsFirstNode_WhenSingleNodeWithBiggerHash()
        {
            // Arrange
            var node = new InMemoryNode(10);
            var nodes = new List<IStorageNode>
            {
                node
            };
            var sut = new ConsistentHash(nodes);

            // Act
            var actual = sut.GetNode(1);

            // Assert
            actual.Should().Be(node);
        }

        [Test]
        public void GetNode_ReturnsFirstNode_WhenSingleNodeWithLowerHash()
        {
            // Arrange
            var node = new InMemoryNode(5);
            var nodes = new List<IStorageNode>
            { 
                node
            };
            var sut = new ConsistentHash(nodes);

            // Act
            var actual = sut.GetNode(10);

            // Assert
            actual.Should().Be(node);
        }

        [Test]
        public void GetNode_ReturnsEmptyNode_WhenNodeListEmpty()
        {
            // Arrange
            var nodes = new List<IStorageNode>();
            var sut = new ConsistentHash(nodes);

            // Act
            var actual = sut.GetNode(10);

            // Assert
            actual.Should().Be(ConsistentHash.EmptyNode);
        }
    }
}