using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DataAccessLayer.Context.Models
{
    

    public class UserAccount
    {
        public int UserAccountID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        //Collection Navigation Reference
        public virtual ICollection<SystemAction> SystemActions { get; set; }
    }

    public class SystemAction
    {
        public int SystemActionID { get; set; }
        public string ActionCode { get; set; }
        public string ActionName { get; set; }
        //Collection Navigation Reference
        public virtual ICollection<UserAccount> UserAccounts { get; set; }
    }

    /*
     USE [testdb27Sep22]
GO
    -- logging -- add connection string in logging service - normally we read from configuration
    -- add this connection strings TrustServerCertificate for certificate of connecting db to work for ef and serilog

    --ILogger<PersonNoteController>  https://stackoverflow.com/questions/57272654/inject-serilogs-ilogger-interface-in-asp-net-core-web-api-controller

    -- very useful link to add middleware / exception hanlding https://code-maze.com/global-error-handling-aspnetcore/

    -- add BaseController to authorise  without baseContoller /or [authorise] keyword userIdentity is not resolved
    -- only single quote or use two fields domain and userId
INSERT INTO [dbo].[UserAccounts]
           ([UserId]
           ,[UserName])
     VALUES
           ('LAPTOP-325PDDR9\asus' , 'Nare Vellela')
GO


INSERT INTO [dbo].[SystemActions]
           ([ActionCode]
           ,[ActionName])
     VALUES
           ('PersonView' , 'Person view')
		   ,('PersonAdd' , 'Person add')
		   ,('PersonDelete' , 'Person delete')
		   ,('PersonUpdate' , 'Person update')


INSERT INTO [dbo].[SystemActionUserAccount]
([SystemActionsSystemActionID]
,[UserAccountsUserAccountID])
VALUES
( 1,1)  --action, user
,(2,1)
,(4,1)



select * from [dbo].[SystemActions]
select * from [dbo].[UserAccounts]



    
CREATE TABLE [dbo].[LogEvents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[MessageTemplate] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[TimeStamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[Properties] [nvarchar](max) NULL,
	[Key] [nvarchar](500) NOT NULL,
	[UserId] [nvarchar](100) NOT NULL,
	[AdditionalInfo] [nvarchar](max) NULL,
 CONSTRAINT [PK_LogEvents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


     
     */


}
