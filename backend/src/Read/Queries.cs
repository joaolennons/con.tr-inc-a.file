using System;

namespace Read
{
    internal static class Queries
    {
        public static class Barbecues
        {
            public const string GetAll = "SELECT Id, Date, Description, Observation FROM Barbecues";

            public static string GetBy(Guid id) => @"SELECT B.*, PA.Id as ParticipantId, PA.Name, P.Value
            FROM Barbecues B
            LEFT JOIN Presence P
            ON B.Id = P.BarbecueId
            LEFT JOIN Participant PA
            ON P.ParticipantId = PA.Id
            WHERE B.ID = 'AA21E3DF-4F58-47FA-1F8B-08D76EF43528'";
            public static string OrderDesc(string field) => $"ORDER BY {field} desc";
        }
    }
}
