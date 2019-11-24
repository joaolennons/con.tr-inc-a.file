using System;

namespace Read
{
    internal static class Queries
    {
        public static class Barbecues
        {
            public const string GetAll = @"SELECT * FROM Barbecues";

            public static string GetBy(Guid id) => $@"SELECT B.*, PA.Id as ParticipantId, PA.Name, P.Value
            FROM Barbecues B
            LEFT JOIN Presence P
            ON B.Id = P.BarbecueId
            LEFT JOIN Participant PA
            ON P.ParticipantId = PA.Id
            WHERE B.ID = '{id}'";
            public static string OrderDesc(string field) => $"ORDER BY {field} desc";
        }

        public static class Participants
        {
            public const string GetAll = @"SELECT * FROM Participant ORDER BY Name";
        }
    }
}
