using System;

namespace SyncProject
{
    public class SyncProcess 
    {
        public SyncProcess()
        {

        }

        private string _schema;

        public SyncProcess(string fileName = null)
        {
        }

        public string Schema
        {
            set
            {
                _schema = value;
            }
            get
            {
                return _schema;
            }
        }

        public event CompleteHandler OnComplete = delegate { };
        
        public delegate void CompleteHandler();
        
        public event UpdateStatusHandler OnUpdateStatus = delegate { };

        public delegate void UpdateStatusHandler(string text, int total, int value);

        public event LoadingHandle OnLoading = delegate { };

        public delegate void LoadingHandle(string text, int total, int value);
        
        public event LoadGrid OnLoadListViewProgresso = delegate { };
        
        public delegate void LoadGrid(string id, string tabela, string registro, int? valor, int? maximo, int? alterados, int? novos, int? excluidos, string status);

        public void Run()
        {
            try
            {
                //Importacao();

                OnComplete?.Invoke();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}