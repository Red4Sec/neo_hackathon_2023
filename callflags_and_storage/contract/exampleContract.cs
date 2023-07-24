using System.ComponentModel;

using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Attributes;
using Neo.SmartContract.Framework.Services;

namespace red4sec
{
    [DisplayName("Example.CallFlags")]
    [ManifestExtra("Author", "Red4Sec")]
    [ManifestExtra("Email", "info@red4sec.com")]
    [ManifestExtra("Description", "This contract is an example")]
    [ContractPermission("*","*")]
    public class exampleContract : SmartContract
    {
        public static void writeTest()
        {
            StorageMap contractStorage = new(Storage.CurrentContext, 0x01);
            contractStorage.Put("myKey", "tested");
        }

        public static void writeTestWithReadOnlyContext()
        {
            StorageMap contractStorage = new(Storage.CurrentReadOnlyContext, 0x01);
            contractStorage.Put("myKey", "tested");
        }

        [Safe]
        public static ByteString readTest()
        {
            StorageMap contractStorage = new(Storage.CurrentReadOnlyContext, 0x01);
            return contractStorage.Get("myKey");
        }

        public object callMe(string method, CallFlags flags)
        {
            return Contract.Call(Runtime.ExecutingScriptHash, method, flags);
        }
    }
}
