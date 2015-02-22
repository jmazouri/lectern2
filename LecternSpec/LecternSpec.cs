using System.Collections.Generic;
using FluentAssertions;
using Lectern2.Core;
using Lectern2.Interfaces;
using Moq;
using NSpec;

namespace LecternSpec
{
    public class describe_lectern : nspec
    {
        private Lectern _testLectern;

        void when_lectern_is_initialized()
        {
            context["without extra modules"] = () =>
            {
                before = () => _testLectern = new Lectern();
                it["should load successfully"] = () =>
                {
                    _testLectern.Should().NotBeNull();
                    _testLectern.Configuration.Should().NotBeNull();
                    _testLectern.Mediator.Should().NotBeNull();
                };
            };

            context["with extra modules"] = () =>
            {
                var mockBridge = new Mock<ILecternBridge>();
                var mockPlugin = new Mock<ILecternPlugin>();
                Network bridgeNetwork = null;
                before = () =>
                {
                    mockBridge.Setup(bridge => bridge.Load(It.IsAny<Network>()))
                        .Returns(true)
                        .Callback<Network>(network => bridgeNetwork = network);

                    mockBridge.Setup(bridge => bridge.Connect()).Returns(true);

                    mockPlugin.Setup(plugin => plugin.Load(It.Is<Network>(network => network == bridgeNetwork)))
                        .Returns(true);

                    _testLectern = new Lectern(
                        additionalBridges: new HashSet<ILecternBridge> {mockBridge.Object},
                        additionalPlugins: new HashSet<ILecternPlugin> {mockPlugin.Object});
                };

                it["should load successfully"] = () =>
                {
                    _testLectern.Should().NotBeNull();
                    _testLectern.Configuration.Should().NotBeNull();

                    bridgeNetwork.Should().NotBeNull();
                    mockBridge.Verify(bridge => bridge.Load(bridgeNetwork));
                    mockPlugin.Verify(plugin => plugin.Load(bridgeNetwork));
                    mockBridge.Verify(bridge => bridge.Connect());

                    _testLectern.Mediator.Should().NotBeNull();
                };

                xit["should unload successfully"] = () =>
                {
                    //_testLectern.Unload()
                    mockBridge.Verify(bridge => bridge.Disconnect("System requested shutdown"));
                    mockPlugin.Verify(plugin => plugin.Unload());
                };
            };
        }

        //post mediator removal
        void when_lectern_is_initialized_2()
        {
            it["should load configuration"] = todo;
            it["should instantiate all the bridges"] = todo;
            it["should create a network for each bridge"] = todo;
            it["should load each bridge"] = todo;
            it["should load each plugin"] = todo;
            it["should connect each bridge"] = todo;
            it["should broadcast when finished"] = todo;
        }
    }
}
