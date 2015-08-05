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

namespace biz.dfch.CS.Unity.Example
{
    /**
     * Here the 'IInjectionCandidate' implementation will be injected by the test class.
     **/
    public class SomeClass : ISomeClass
    {
        private IInjectionCandidate _injectionCandidate;

        /**
         * Sample constructor for constructor injection
         **/
        public SomeClass(IInjectionCandidate injectionCandidate)
        {
            _injectionCandidate = injectionCandidate;
        }

        public String GetNameOfInjectedCandidate()
        {
            return _injectionCandidate.GetName();
        }
    }
}
