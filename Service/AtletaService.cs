using DbLibrary;
using ProjectAtleti.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAtleti.Service
{
    public class AtletaService
    {
        public AtletaService()
        {

        }

        public List<AtletaEntity> GetAll()
        {
            List<AtletaEntity> atletiList = new List<AtletaEntity>();
            List<Atleta> atletiDb = new List<Atleta>();

            using (var db = new AtletiDbEntities())
            {
                atletiDb = db.Atleta.ToList();
            }

            atletiDb.ForEach((item) => { atletiList.Add(item.ToAtletaEntity()); });

            return atletiList;
        }

        public AtletaEntity getAtletaById(int atletaId)
        {
            AtletaEntity atleta = null;

            using (var db = new AtletiDbEntities())
            {
                atleta = db.Atleta.FirstOrDefault(x => x.AtletaId == atletaId).ToAtletaEntity();
            }

            return atleta;
        }

        public int Add(AtletaEntity atleta)
        {
            if (atleta != null)
            {
                using (var db = new AtletiDbEntities())
                {
                    db.Atleta.Add(atleta.ToDbAtleta());
                    db.SaveChanges();
                }
                return 0;
            }
            return -1;
        }

        public int Delete(AtletaEntity atleta)
        {
            if (atleta != null)
            {
                using (var db = new AtletiDbEntities())
                {
                    db.Atleta.Remove(atleta.ToDbAtleta());
                    db.SaveChanges();
                }
                return 0;
            }
            return -1;
        }

        public int Update(AtletaEntity atleta)
        {
            int result = 0;
            if (atleta != null)
            {
                using (var db = new AtletiDbEntities())
                {
                    Atleta atletaDb = db.Atleta.FirstOrDefault(x=> atleta.AtletaId == x.AtletaId);
                    if (atletaDb == null)
                        result = -1;
                    else
                    {
                        atletaDb = atleta.ToDbAtleta(atletaDb);
                        db.SaveChanges();
                    }
                }
                
            }
            return result;
        }
    }

    public static class AtletaDBMapper
    {
        public static AtletaEntity ToAtletaEntity(this Atleta atleta)
        {             
            return new AtletaEntity()
            {
                AtletaId = atleta.AtletaId,
                Name = atleta.AtletaName,
                Surname = atleta.AtletaSurname,
                BirthDay = atleta.AtletaBirthday,
                FiscalCode = atleta.AtletaCFD,
                NrCartellino = atleta.AtletaNrCartellino,
                Sex = atleta.AtletaSex
            };
        }

        public static Atleta ToDbAtleta(this AtletaEntity atletaEntity, Atleta atleta = null)
        {
            if (atleta == null)
                atleta = new Atleta();

            atleta.AtletaId = atletaEntity.AtletaId;
            atleta.AtletaName = atletaEntity.Name;
            atleta.AtletaSurname = atletaEntity.Surname;
            atleta.AtletaBirthday = atletaEntity.BirthDay;
            atleta.AtletaCFD = atletaEntity.FiscalCode;
            atleta.AtletaNrCartellino = atletaEntity.NrCartellino;
            atleta.AtletaSex = atletaEntity.Sex;

            return atleta;
        }
    }
}
