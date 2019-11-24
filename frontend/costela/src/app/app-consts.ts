const basePath = "http://localhost:44397/trinca/api/v1/";
export const Api = {
  barbecue: `${basePath}Barbecue`,
  participants: bbqId => `${basePath}Barbecue/${bbqId}/participants`,
  people: `${basePath}people`
};
