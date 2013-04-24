
namespace GRW.Integrador.Modelo.Entidades
{
    public class UsuarioEntidad
    {
        #region Propiedades

        private string _nombre;
        private int _allowDbChanges;
        private int _allowAutoConf;
        private int _allowUserAdmin;
        private int _allowInterface;
        private int _allowInvControl;
        private int _allowAccount;
        private int _allowCostCenter;
        private int _allowJournal;
        private int _allowFileRead;
        private int _allowDiscReport;
        private int _allowReprocess;
        
        public int AllowDbChanges
        {
            get { return _allowDbChanges; }
            set { _allowDbChanges = value; }
        }

        public int AllowAutoConf
        {
            get { return _allowAutoConf; }
            set { _allowAutoConf = value; }
        }

        public int AllowUserAdmin
        {
            get { return _allowUserAdmin; }
            set { _allowUserAdmin = value; }
        }

        public int AllowInterface
        {
            get { return _allowInterface; }
            set { _allowInterface = value; }
        }

        public int AllowInvControl
        {
            get { return _allowInvControl; }
            set { _allowInvControl = value; }
        }

        public int AllowAccount
        {
            get { return _allowAccount; }
            set { _allowAccount = value; }
        }

        public int AllowCostCenter
        {
            get { return _allowCostCenter; }
            set { _allowCostCenter = value; }
        }

        public int AllowJournal
        {
            get { return _allowJournal; }
            set { _allowJournal = value; }
        }

        public int AllowFileRead
        {
            get { return _allowFileRead; }
            set { _allowFileRead = value; }
        }

        public int AllowDiscReport
        {
            get { return _allowDiscReport; }
            set { _allowDiscReport = value; }
        }

        public int AllowReprocess
        {
            get { return _allowReprocess; }
            set { _allowReprocess = value; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        #endregion Propiedades

        public UsuarioEntidad()
        {
        }
       
        public UsuarioEntidad(string nombre, int allowDbChanges, int allowAutoConf, int allowUserAdmin, int allowInterface,
            int allowInvControl, int allowAccount, int allowCostCenter, int allowJournal, int allowFileRead,
            int allowDiscReport, int allowReprocess)
        {
            Nombre = nombre;
            AllowDbChanges = allowDbChanges;
            AllowAutoConf = allowAutoConf;
            AllowUserAdmin = allowUserAdmin;
            AllowInterface = allowInterface;
            AllowInvControl = allowInvControl;
            AllowAccount = allowAccount;
            AllowCostCenter = allowCostCenter;
            AllowJournal = allowJournal;
            AllowFileRead = allowFileRead;
            AllowDiscReport = allowDiscReport;
            AllowReprocess = allowReprocess;
        }

    }
}
