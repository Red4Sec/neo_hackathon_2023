using System.ComponentModel;

using Neo;
using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Services;

namespace red4sec
{
    [DisplayName("Example.Witness")]
    [ManifestExtra("Author", "Red4Sec")]
    [ManifestExtra("Email", "info@red4sec.com")]
    [ManifestExtra("Description", "This contract is an example")]
    [ContractPermission("*","*")]
    public class exampleContract : SmartContract
    {
        [Safe]
        public static bool checkWitness(UInt160 hash)
        {
            return Runtime.CheckWitness(hash);
        }

        public object checkWitnessWithCall(UInt160 hash)
        {
            return Contract.Call(Runtime.ExecutingScriptHash, "checkWitness", CallFlags.None, hash);
        }
    }
}
