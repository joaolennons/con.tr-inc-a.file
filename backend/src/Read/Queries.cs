using System;

namespace Read
{
    internal static class Queries
    {
        public static class Barbecues
        {
            public const string GetAll = @"SELECT B.*, SUM(COALESCE(P.Value, 0)) TotalAmount, COUNT(PA.Id) TotalParticipants
            FROM Barbecues B
            LEFT JOIN Presence P
            ON B.Id = P.BarbecueId
            LEFT JOIN Participant PA
            ON P.ParticipantId = PA.Id
            GROUP BY B.Id, B.Date, B.Description, B.Observation";

            public static string GetBy(Guid id) => $@"SELECT B.*, PA.Id as ParticipantId, PA.Name, P.Value
            FROM Barbecues B
            LEFT JOIN Presence P
            ON B.Id = P.BarbecueId
            LEFT JOIN Participant PA
            ON P.ParticipantId = PA.Id
            WHERE B.ID = '{id}'";
            public static string OrderDesc(string field) => $"ORDER BY {field} desc";
        }
    }
}
