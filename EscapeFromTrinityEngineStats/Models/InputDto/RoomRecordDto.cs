using StatisticsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EscapeFromTrinityEngineStats.Models.InputDto
{
    internal class RoomRecordDto
    {
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        public int LevelNumber { get; set; }
        public virtual BattleRecordDto? BattleRecordDto { get; set; }
        public virtual EventRecordDto? EventRecordDto { get; set; }
        public virtual ShopRecordDto? ShopRecordDto { get; set; }
        public virtual RewardRecordDto? RewardRecordDto { get; set; }
    }
}
