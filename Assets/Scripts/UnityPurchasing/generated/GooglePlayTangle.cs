// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Uw3NAViCEZ4DPIYnVJNoLnYpgfvCokdcMJ+C5+LObkCbsxYwifD84OYHW9fI27uDN3K/Y0FSXIkihEsXKMUBvQF5RRKJkfxehHknZ3FiO2t5PRbrjl60A9YdltAXzhKRK7FIGmk6oUxXZHbsmMSDjauqiIO80e6paerk69tp6uHpaerq602+HFSv50DPEpmooLhfnxqZQEah3e+1zziIrztPurCkTJAeaPgmr75M2dvVT6kIeOPueNYF69HxGSu5Ne3ZgAhsFFywY+XRYqLoWQtykdkjVCYeuDQFDmHsGqbCwY6cQZtVq8f38Cphm5xr22nqydvm7eLBbaNtHObq6uru6+gLnw3E14+xUySfeTqGc+N8pp5Vk7AJfa/zJHgDPOno6uvq");
        private static int[] order = new int[] { 2,8,4,6,11,13,8,12,10,12,12,12,12,13,14 };
        private static int key = 235;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
