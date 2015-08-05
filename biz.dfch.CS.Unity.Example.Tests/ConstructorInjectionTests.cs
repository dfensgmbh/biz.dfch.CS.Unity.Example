/**
 * Copyright 2015 Marc Rufer, d-fens GmbH
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Unity.Example.Tests
{
    [TestClass]
    public class ConstructorInjectionTests
    {
        private UnityContainer _container;

        [TestMethod]
        public void SimpleConstructorInjectionByTypeTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IObjectToInject, SimpleObjectToInject>();
            var objectWithInjection = _container.Resolve<ConstructorInjection>();
            Assert.AreEqual(42, objectWithInjection.GetIdOfInjectedObject());
        }

        [TestMethod]
        public void ConstructorInjectionByTypeWithConstructorArgumentsTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IObjectToInject, ObjectToInjectWithCustomConstructor>(
                new InjectionConstructor(77));
            var objectWithInjection = _container.Resolve<ConstructorInjection>();
            Assert.AreEqual(77, objectWithInjection.GetIdOfInjectedObject());
        }

        [TestMethod]
        public void ConstructorInjectionByTypeWithConstructorArgumentsProvidedAtResolveTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IObjectToInject, ObjectToInjectWithCustomConstructor>(
                new InjectionConstructor(typeof(int)));
            var objectWithInjection = _container.Resolve<ConstructorInjection>(
                new ParameterOverride("id", 77));
            Assert.AreEqual(77, objectWithInjection.GetIdOfInjectedObject());
        }
    }
}
