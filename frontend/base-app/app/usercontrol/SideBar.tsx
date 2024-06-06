"use client";

import { Flowbite, Sidebar } from "flowbite-react";
import {
  HiArrowSmRight,
  HiChartPie,
  HiInbox,
  HiShoppingBag,
  HiTable,
  HiUser,
  HiViewBoards,
  HiCube,
} from "react-icons/hi";
import { sidebarCustomTheme } from "./CustomSideBar";

export default function SideBar() {
  return (
    <Sidebar
      theme={sidebarCustomTheme}
      aria-label="Default sidebar example"
      className="float-left fixed z-50"
    >
      <Sidebar.Items className="bg-orange-500 h-full pl-0">
        <Sidebar.ItemGroup>
          <Sidebar.Item href="/session" icon={HiChartPie}>
            Dashboard
          </Sidebar.Item>
          <Sidebar.Collapse icon={HiCube} label="Base Info">
            <Sidebar.Item href="/companies">Companies</Sidebar.Item>
            <Sidebar.Item href="#">Sales</Sidebar.Item>
            <Sidebar.Item href="#">Refunds</Sidebar.Item>
            <Sidebar.Item href="#">Shipping</Sidebar.Item>
          </Sidebar.Collapse>
          <Sidebar.Item
            href="#"
            icon={HiViewBoards}
            label="Pro"
            labelColor="dark"
          >
            Kanban
          </Sidebar.Item>
          <Sidebar.Item href="#" icon={HiInbox} label="3">
            Inbox
          </Sidebar.Item>
          <Sidebar.Item href="#" icon={HiUser}>
            Users
          </Sidebar.Item>
          <Sidebar.Item href="#" icon={HiShoppingBag}>
            Products
          </Sidebar.Item>
          <Sidebar.Item href="#" icon={HiArrowSmRight}>
            Sign In
          </Sidebar.Item>
          <Sidebar.Item href="#" icon={HiTable}>
            Sign Up
          </Sidebar.Item>
        </Sidebar.ItemGroup>
      </Sidebar.Items>
    </Sidebar>
  );
}
