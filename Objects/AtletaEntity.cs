using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAtleti.Objects
{
    public class AtletaEntity
    {
        public AtletaEntity()
        {
            AtletaId = -1;
        }

        private int m_AtletaId;

        public int AtletaId
        {
            get { return m_AtletaId; }
            set { m_AtletaId = value; }
        }

        private string m_Surname;

        public string Surname
        {
            get { return m_Surname; }
            set { m_Surname = value; }
        }

        private string m_Name;

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        private int m_NrCartellino;

        public int NrCartellino
        {
            get { return m_NrCartellino; }
            set { m_NrCartellino = value; }
        }

        private string m_FC;

        public string FiscalCode
        {
            get { return m_FC; }
            set { m_FC = value; }
        }

        private char? m_Sex = null;

        public string Sex
        {
            get
            {
                switch (m_Sex)
                {
                    case 'M': return "Uomo";
                    case 'F': return "Donna";
                    default: return "Non definito";
                }
            }

            set
            {
                m_Sex = Convert.ToChar(value);
            }
        }

        private DateTime? m_BirthDay;

        public DateTime? BirthDay
        {
            get { return m_BirthDay; }
            set { m_BirthDay = value; }
        }

    }
}
