using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAtleti.Objects
{
    public class AtletaEntity : INotifyPropertyChanged
    {
        public AtletaEntity()
        {
            AtletaId = -1;
            m_Sex = 'N';
        }

        private int m_AtletaId;

        public int AtletaId
        {
            get { return m_AtletaId; }
            set
            {
                m_AtletaId = value;
                NotifyPropertyChanged(nameof(AtletaId));
            }
        }

        private string m_Surname;

        public string Surname
        {
            get { return m_Surname; }
            set
            {
                m_Surname = value;
                NotifyPropertyChanged(nameof(Surname));
            }
        }

        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set
            {
                m_Name = value;
                NotifyPropertyChanged(nameof(Name));
            }
        }

        private int m_NrCartellino;

        public int NrCartellino
        {
            get { return m_NrCartellino; }
            set
            {
                m_NrCartellino = value;
                NotifyPropertyChanged(nameof(NrCartellino));
            }
        }

        private string m_FC;

        public string FiscalCode
        {
            get { return m_FC; }
            set
            {
                m_FC = value;
                NotifyPropertyChanged(nameof(FiscalCode));
            }
        }

        private char m_Sex;

        public char Sex
        {
            get
            {
                return m_Sex;
            }

            set
            {
                m_Sex = Convert.ToChar(value);
                NotifyPropertyChanged(nameof(Sex));
            }
        }

        public string SexString
        {
            get
            {
                switch (m_Sex)
                {
                    case 'M': return "Uomo";
                    case 'F': return "Donna";
                    case 'N': return "Non definito";
                    default: return string.Empty;
                }
            }
        }
        private DateTime? m_BirthDay;       

        public DateTime? BirthDay
        {
            get { return m_BirthDay; }
            set { m_BirthDay = value; NotifyPropertyChanged(nameof(BirthDay)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
