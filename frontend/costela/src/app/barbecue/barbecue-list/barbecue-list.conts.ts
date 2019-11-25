export const Columns = [
  { property: "date", label: "Quando?", type: "date" },
  { property: "description", label: "A troco de quê?" },
  { property: "totalParticipants", label: "Quantos vão?" },
  {
    property: "totalAmount",
    label: "Valor a ser arrecadado",
    type: "currency",
    format: "BRL"
  },
  {
    property: "totalRaised",
    label: "Quanto já foi pago?",
    type: "currency",
    format: "BRL"
  }
];

export const BbqFormRoute = "new-bbq";
