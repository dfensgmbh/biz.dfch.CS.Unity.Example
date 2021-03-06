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
     * Implementation of an injection candidate with a constructor argument
     **/
    public class InjectionCandidateWithCustomConstructor : IInjectionCandidate
    {
        private String _name;

        public InjectionCandidateWithCustomConstructor(String name)
        {
            _name = name;
        }

        public String GetName()
        {
            return _name;
        }
    }
}
