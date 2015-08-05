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
    public class InjectionWithRuntimeInformationTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = "A name";
            var _container = new UnityContainer();
            _container.RegisterType<IInjectionCandidate, InjectionCandidateWithCustomConstructor>(
                new InjectionConstructor(typeof(String)));
            _container.RegisterType<ISomeClassFactory, SomeClassFactory>();
            var factory = _container.Resolve<ISomeClassFactory>();
            Assert.AreEqual(name, factory.Create(name).GetNameOfInjectedCandidate());
        }
    }
}
