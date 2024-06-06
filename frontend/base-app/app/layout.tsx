import type { Metadata } from "next";
import "./globals.css";
import SideBar from "./usercontrol/SideBar";
import NavBar from "./usercontrol/NavBar";
import BreadCrumb from "./usercontrol/BreadCrumb";

export const metadata: Metadata = {
  title: "Create Next App",
  description: "Generated by create next app",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html className="h-full bg-white" lang="en">
      <body className="bg-white text-gray-600 antialiased dark:bg-gray-900 dark:text-gray-400">
        <NavBar />
        <div className="flex">
          <div className="flex-none w-64 mt-16">
            <SideBar />
          </div>
          <div className="grow m-2 mt-16"><BreadCrumb/> {children}</div>
        </div>
      </body>
    </html>
  );
}
