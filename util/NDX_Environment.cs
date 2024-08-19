using System;
using System.Diagnostics;

namespace NeonDX
{
    /**
     * 環境情報
     */
    public sealed class NDX_Environment : NDX_Object
    {
        private long _working_set;
        private string _os_version = string.Empty;
        private bool _is_64bit_os;
        private bool _is_64bit_proc;
        private int _processors;

        /**
         * 物理メモリ使用量
         */
        public long WorkingSet
        {
            get { return _working_set; }
        }

        /**
         * OSバージョン
         */
        public string OSVersion
        {
            get { return _os_version; }
        }

        /**
         * 64ビットOSか
         */
        public bool Is64bitOS
        {
            get { return _is_64bit_os; }
        }

        /**
         * 64ビットプロセスか
         */
        public bool Is64bitProcess
        {
            get { return _is_64bit_proc; }
        }

        /**
         * プロセッサ数
         */
        public int Processors
        {
            get { return _processors; }
        }

        /**
         * コンストラクタ
         */
        internal NDX_Environment()
        {
            _working_set = 0;
        }

        /**
         * 初期化
         */
        public override void Init()
        {
            _os_version = Environment.OSVersion.VersionString;
            _is_64bit_os = Environment.Is64BitOperatingSystem;
            _is_64bit_proc = Environment.Is64BitProcess;
            _processors = Environment.ProcessorCount;
        }

        /**
         * 更新
         */
        public override void Update()
        {
            _working_set = Environment.WorkingSet * 100 / 1024 / 1024;
        }
    }
}
