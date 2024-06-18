

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class DareCriteria
    {
        public const short Id = 501;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public sbyte type;
        public int[] _params;
        
        public DareCriteria()
        {
        }
        
        public DareCriteria(sbyte type, int[] __params)
        {
            this.type = type;
            this._params = __params;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteSbyte(type);
            writer.WriteShort((short)_params.Length);
            foreach (var entry in _params)
            {
                 writer.WriteInt(entry);
            }
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            type = reader.ReadSbyte();
            var limit = (ushort)reader.ReadUShort();
            _params = new int[limit];
            for (int i = 0; i < limit; i++)
            {
                 _params[i] = reader.ReadInt();
            }
        }
        
    }
    
}