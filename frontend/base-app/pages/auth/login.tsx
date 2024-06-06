import "@/app/globals.css";
import { authOptions } from "@/app/api/auth/[...nextauth]/route";
import type {
  GetServerSidePropsContext,
  InferGetServerSidePropsType,
} from "next";
import { getServerSession } from "next-auth";
import { getCsrfToken } from "next-auth/react";

export default function SignIn({
  csrfToken,
}: InferGetServerSidePropsType<typeof getServerSideProps>) {
  return (
    <div className="flex h-screen min-h-full flex-col justify-center px-6 lg:px-8">
      <div className="p-5 sm:mx-auto sm:w-full sm:max-w-sm  bg-orange-500">
        <img
          className="mx-auto w-auto"
          src="/logo.jpg"
          alt="Your Company"
        />
      </div>

      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <form
          className="space-y-6"
          method="post"
          action="/api/auth/callback/credentials"
        >
          <input name="csrfToken" type="hidden" defaultValue={csrfToken} />
          <div>
            <label
              htmlFor="username"
              className="block text-sm font-medium leading-6 text-gray-900"
            >
              Username/Email
            </label>
            <div className="mt-2">
              <input
                id="username"
                name="username"
                type="username"
                autoComplete="username"
                required
                className="block w-full rounded-md border-0 p-2 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
              />
            </div>
          </div>

          <div>
            <div className="flex items-center justify-between">
              <label
                htmlFor="password"
                className="block text-sm font-medium leading-6 text-gray-900"
              >
                Password
              </label>
            </div>
            <div className="mt-2">
              <input
                id="password"
                name="password"
                type="password"
                autoComplete="current-password"
                required
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
              />
            </div>
          </div>

          <div>
            <button
              type="submit"
              className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
            >
              Sign in
            </button>
          </div>
        </form>
      </div>
    </div>
  );
}

export async function getServerSideProps(context: GetServerSidePropsContext) {
  const session = await getServerSession(context.req, context.res, authOptions);
  if (session) {
    return { redirect: { destination: "/" } };
  }
  return {
    props: {
      csrfToken: await getCsrfToken(context),
    },
  };
}
