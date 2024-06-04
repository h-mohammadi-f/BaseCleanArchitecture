import { DefaultSession } from "next-auth";

declare module "next-auth" {
  interface Session {
    user: {
      username: string;
      apitoken: string;
    } & DefaultSession["user"];
  }

  interface User {
    username: string;
    token: string;
  }
}

declare module "next-auth/jwt" {
  interface JWT {
    username: string;
    apitoken: string;
  }
}
