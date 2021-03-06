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
using Microsoft.Practices.Unity.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Unity.Example.Tests
{
    [TestClass]
    public class XMLContainerConfigurationTest
    {
        private IUnityContainer _container;
        private const String SIMPLE_INJECTION_CANDIDATE = "Simple Injection Candidate";

        [TestMethod]
        public void ConstructorInjectionWithConfigurationFromXMLTest()
        {
            _container = new UnityContainer();
            _container.LoadConfiguration();

            var objectWithInjection = _container.Resolve<SomeClass>();

            Assert.AreEqual(SIMPLE_INJECTION_CANDIDATE, objectWithInjection.GetNameOfInjectedCandidate());
        }
    }
}
