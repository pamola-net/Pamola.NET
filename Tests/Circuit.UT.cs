using System;
using System.Linq;
using Xunit;
using System.Collections.Generic;

namespace Pamola.UT
{
    public class CircuitUT
    {
        [Fact]
        public void AppendComponents()
        {
            var element = new MockedElement(2);
            var circuit = element.GetCircuit();

            Assert.Contains(element, circuit.Components);
            Assert.All(element.Terminals, terminal => Assert.Contains(terminal, circuit.Components));
        }

        [Fact]
        public void AvoidConnectedTerminals()
        {
            MockedElement element = new MockedElement(3);
        
            var (terminalL, terminalR) = 
                (element.Terminals.First(),element.Terminals.Last());

            terminalL.ConnectTo(terminalR);

            var circuit = terminalL.GetCircuit();

            Assert.Single(circuit.Terminals);
        }

        [Fact]
        public void AppendComplexConnections()
        {
            MockedElement element1 = new MockedElement(2);
            MockedElement element2 = new MockedElement(2);
            MockedElement element3 = new MockedElement(3);

            var n1 = element1.Terminals.First().
                ConnectTo(element2.Terminals.First()).
                ConnectTo(element3.Terminals.First());

            var n2 = element1.Terminals.Last().
                ConnectTo(element2.Terminals.Last()).
                ConnectTo(element3.Terminals.Last());

            var circuit = n1.GetCircuit();

            var elements = new[] { element1, element2, element3 };
            var terminals = elements.SelectMany(element => element.Terminals);
            var nodes = new[] { n1, n2 };

            var components = (new[]{
                elements.Cast<IComponent>(),
                terminals.Cast<IComponent>(),
                nodes.Cast<IComponent>()}).
                SelectMany(cSerie=> cSerie);    
        
            Assert.Empty(components.Except(circuit.Components));
            Assert.Empty(circuit.Components.Except(components));
        }

        [Fact]
        public void VariablesContainsAllComponentsVariables()
        {
            MockedElement element1 = new MockedElement(2);
            MockedElement element2 = new MockedElement(2);

            var circuit = element1.Terminals.First().ConnectTo(element2.Terminals.First()).GetCircuit();

            var circuitVariables = ((IComponent)circuit).Variables;

            var componentsVariables = circuit.Components.SelectMany(component => component.Variables);

            var complex = new System.Numerics.Complex(1.0, 1.0);

            componentsVariables.ToList().ForEach(variable => variable.Setter(complex));

            Assert.NotEmpty(circuitVariables);
            Assert.NotEmpty(componentsVariables);
            Assert.All(circuitVariables, variable => Assert.Equal(complex, variable.Getter()));

        }

        [Fact]
        public void EquationsContainsAllComponentsEquations()
        {
            MockedElement element1 = new MockedElement(2);
            MockedElement element2 = new MockedElement(2);

            var circuit = element1.Terminals.First().ConnectTo(element2.Terminals.First()).GetCircuit();

            var circuitEquations = ((IComponent)circuit).Equations;

            var componentsEquations = circuit.Components.SelectMany(component => component.Equations);

            Assert.NotEmpty(circuitEquations);
            Assert.NotEmpty(componentsEquations);
            Assert.Empty(circuitEquations.Except(componentsEquations));
            Assert.Empty(componentsEquations.Except(circuitEquations));

        }

    }
}
