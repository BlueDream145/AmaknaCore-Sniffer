

// Generated on 04/03/2020 21:59:11
using System;
using System.Collections.Generic;
using System.Linq;
using AmaknaProxy.API.IO;

namespace AmaknaProxy.API.Protocol.Types
{
    public class AbstractContactInformations
    {
        public const short Id = 380;
        public virtual short TypeId
        {
            get { return Id; }
        }
        
        public int accountId;
        public string accountName;
        
        public AbstractContactInformations()
        {
        }
        
        public AbstractContactInformations(int accountId, string accountName)
        {
            this.accountId = accountId;
            this.accountName = accountName;
        }
        
        public virtual void Serialize(IDataWriter writer)
        {
            writer.WriteInt(accountId);
            writer.WriteUTF(accountName);
        }
        
        public virtual void Deserialize(IDataReader reader)
        {
            accountId = reader.ReadInt();
            accountName = reader.ReadUTF();
        }
        
    }
    
}