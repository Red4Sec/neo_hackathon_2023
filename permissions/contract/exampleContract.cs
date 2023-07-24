using System.ComponentModel;

using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Services;
using Neo.SmartContract.Framework.Native;

namespace red4sec
{
    [DisplayName("Example.Permissions")]
    [ManifestExtra("Author", "Red4Sec")]
    [ContractPermission("*", "ping")]
    public class exampleContract : SmartContract
    {
        //[Safe] // Try with and without safe
        public static int ping(int x) => x;

        public void updateManifest(ByteString newManifest)
        {
            newManifest = StdLib.Base64Decode(newManifest);
            ContractManagement.Update(null, newManifest);
        }

        public object externalCallPing(int value)
        {
            return Contract.Call(Runtime.ExecutingScriptHash, "ping", CallFlags.None, value);
        }
    }
}
