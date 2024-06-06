"use client";

import { Breadcrumb } from "flowbite-react";
import { usePathname } from "next/navigation";
import { HiHome } from "react-icons/hi";
import * as changeCase from "change-case";


export default function BreadCrumb() {
  const paths = usePathname();
  const pathNames = paths!.split("/").filter((path) => path);
  return (
    <Breadcrumb
      aria-label="Solid background breadcrumb example"
      className="bg-gray-50 px-5 py-3 dark:bg-gray-800"
    >
      <Breadcrumb.Item href="/" icon={HiHome}>
        Home
      </Breadcrumb.Item>
      {pathNames.length > 0}
      {pathNames.map((link, index) => {
        return (
          <Breadcrumb.Item key={index} href="#">
            {changeCase.capitalCase(link)}
          </Breadcrumb.Item>
        );
      })}
    </Breadcrumb>
  );
}
