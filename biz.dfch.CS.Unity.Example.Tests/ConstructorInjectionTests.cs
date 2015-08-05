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
using biz.dfch.CS.Unity.Example.Interfaces;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace biz.dfch.CS.Unity.Example.Tests
{
    [TestClass]
    public class ConstructorInjectionTests
    {
        private const String SIMPLE_INJECTION_CANDIDATE = "Simple Injection Candidate";
        private const String INJECTION_CANDIDATE_WITH_CUSTOM_CONSTRUCTOR_NAME = "Injection Candidate With Custom Constructor";

        private UnityContainer _container;

        [TestMethod]
        public void SimpleConstructorInjectionByTypeTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IInjectionCandidate, SimpleInjectionCandidate>();
            var objectWithInjection = _container.Resolve<SomeClass>();
            Assert.AreEqual(SIMPLE_INJECTION_CANDIDATE, objectWithInjection.GetNameOfInjectedCandidate());
        }

        [TestMethod]
        public void ConstructorInjectionByTypeWithConstructorArgumentsTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IInjectionCandidate, InjectionCandidateWithCustomConstructor>(
                new InjectionConstructor(INJECTION_CANDIDATE_WITH_CUSTOM_CONSTRUCTOR_NAME));
            var objectWithInjection = _container.Resolve<SomeClass>();
            Assert.AreEqual(INJECTION_CANDIDATE_WITH_CUSTOM_CONSTRUCTOR_NAME, objectWithInjection.GetNameOfInjectedCandidate());
        }

        [TestMethod]
        public void ConstructorInjectionByTypeWithConstructorArgumentsProvidedAtResolveTest()
        {
            _container = new UnityContainer();
            _container.RegisterType<IInjectionCandidate, InjectionCandidateWithCustomConstructor>(
                new InjectionConstructor(typeof(String)));
            var objectWithInjection = _container.Resolve<SomeClass>(
                new ParameterOverride("name", INJECTION_CANDIDATE_WITH_CUSTOM_CONSTRUCTOR_NAME));
            Assert.AreEqual(INJECTION_CANDIDATE_WITH_CUSTOM_CONSTRUCTOR_NAME, objectWithInjection.GetNameOfInjectedCandidate());
        }
    }
}
