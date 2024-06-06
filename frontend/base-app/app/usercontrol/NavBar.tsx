"use client";
import {
  Avatar,
  Dropdown,
  DropdownDivider,
  DropdownHeader,
  DropdownItem,
  Navbar,
  NavbarBrand,
} from "flowbite-react";
import { signOut } from "next-auth/react";
import { getCurrentUser } from "../actions/authActions";

export default function NavBar() {
  const user = getCurrentUser()
  console.log(user);
  return (
    <Navbar fluid className="bg-orange-400 fixed w-screen h-16 z-50">
      <NavbarBrand href="https://flowbite-react.com">
        <img
          src="/logo.jpg"
          className="mr-3 h-6 sm:h-9"
          alt="Flowbite React Logo"
        />
        <span className="self-center whitespace-nowrap text-xl font-semibold dark:text-white">
          Flowbite React
        </span>
      </NavbarBrand>
      <div className="md:order-2">
        <Dropdown
          arrowIcon={false}
          inline
          label={
            <Avatar
              alt="User settings"
              img="https://flowbite.com/docs/images/people/profile-picture-5.jpg"
              rounded
            />
          }
        >
          <DropdownHeader>
            <span className="block text-sm">Bonnie Green</span>
            <span className="block truncate text-sm font-medium">
              name@flowbite.com
            </span>
          </DropdownHeader>
          <DropdownItem>Dashboard</DropdownItem>
          <DropdownItem>Settings</DropdownItem>
          <DropdownItem>Earnings</DropdownItem>
          <DropdownDivider />
          <DropdownItem onClick={() => signOut()}>Sign out</DropdownItem>
        </Dropdown>
      </div>
    </Navbar>
  );
}
