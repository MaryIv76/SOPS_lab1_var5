using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace lab1_var5.Models
{
    public class DBConnector
    {
        ApplicationContext db;

        public DBConnector(ApplicationContext db)
        {
            this.db = db;
        }

        public List<Player> getPlayerByQuery(FindPlayer findPlayer)
        {
            String sqlRequest = "SELECT * FROM roster ";

            if (hasNoQueryParameters(findPlayer))
            {
                return db.Player.FromSqlRaw(sqlRequest).ToList();
            }

            sqlRequest += "WHERE ";
            bool isFirstParameter = true;

            String[] conditions = new String[4];
            conditions[0] = getPositionCondition(findPlayer.position);
            conditions[1] = getBirthdayCondition(findPlayer.startBirthday, findPlayer.endBirthday);
            conditions[2] = getWeightCondition(findPlayer.minWeight, findPlayer.maxWeight);
            conditions[3] = getHeightCondition(findPlayer.minHeight, findPlayer.maxHeight);
            foreach (String condition in conditions)
            {
                if (!condition.Equals(""))
                {
                    if (!isFirstParameter)
                    {
                        sqlRequest += "AND ";
                    }
                    sqlRequest += condition;
                    isFirstParameter = false;
                }
            }
            return db.Player.FromSqlRaw(sqlRequest).ToList();
        }

        public bool hasNoQueryParameters(FindPlayer findPlayer)
        {
            return findPlayer.position.Equals("no")
               && findPlayer.startBirthday == null
               && findPlayer.endBirthday == null
               && findPlayer.minWeight == null
               && findPlayer.maxWeight == null
               && findPlayer.minHeight == null
               && findPlayer.maxHeight == null;
        }

        public String getPositionCondition(String? position)
        {
            String condition = "";
            if (!position.Equals("no"))
            {
                condition += $"position LIKE \"{position}\" ";
            }
            return condition;
        }

        public String getBirthdayCondition(DateTime? startBirthday, DateTime? endBirthday)
        {
            String condition = "";
            if (startBirthday != null || endBirthday != null)
            {
                if (startBirthday != null && endBirthday != null)
                {
                    condition += $"date(birthday) BETWEEN \"{startBirthday?.Date.ToString("yyyy-MM-dd")}\" " +
                        $"AND \"{endBirthday?.Date.ToString("yyyy-MM-dd")}\" ";

                }
                else if (startBirthday != null)
                {
                    condition += $"date(birthday) >= \"{startBirthday?.Date.ToString("yyyy-MM-dd")}\" ";
                }
                else if (endBirthday != null)
                {
                    condition += $"date(birthday) <= \"{endBirthday?.Date.ToString("yyyy-MM-dd")}\" ";
                }
            }
            return condition;
        }

        public String getWeightCondition(int? minWeight, int? maxWeight)
        {
            String condition = "";
            if (minWeight != null || maxWeight != null)
            {
                if (minWeight != null && maxWeight != null)
                {
                    condition += $"weight BETWEEN \"{minWeight}\" AND \"{maxWeight}\" ";

                }
                else if (minWeight != null)
                {
                    condition += $"weight >= \"{minWeight}\" ";
                }
                else if (maxWeight != null)
                {
                    condition += $"weight <= \"{maxWeight}\" ";
                }
            }
            return condition;
        }

        public String getHeightCondition(int? minHeight, int? maxHeight)
        {
            String condition = "";
            if (minHeight != null || maxHeight != null)
            {
                if (minHeight != null && maxHeight != null)
                {
                    condition += $"height BETWEEN \"{minHeight}\" AND \"{maxHeight}\" ";

                }
                else if (minHeight != null)
                {
                    condition += $"height >= \"{minHeight}\" ";
                }
                else if (maxHeight != null)
                {
                    condition += $"height <= \"{maxHeight}\" ";
                }
            }
            return condition;
        }

        public List<TrackRecord> getTrackRecordByQuery(String playerid)
        {
            String sqlRequest = $"SELECT * FROM trackRecordPlayer WHERE playerid LIKE \"{playerid}\"";
            return db.TrackRecords.FromSqlRaw(sqlRequest).ToList();
        }

        public Player getPlayerById(String playerid)
        {
            String sqlRequest = $"SELECT * FROM roster WHERE playerid LIKE \"{playerid}\"";
            List<Player> player = db.Player.FromSqlRaw(sqlRequest).ToList();
            return player[0];
        }
    }
}
