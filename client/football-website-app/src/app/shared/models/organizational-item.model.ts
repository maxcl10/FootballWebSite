export interface OrganizationalItem {
  title: string;
  persons: Person[];
}

export interface Person {
  firstName: string;
  lastName: string;
  title: string;
}
