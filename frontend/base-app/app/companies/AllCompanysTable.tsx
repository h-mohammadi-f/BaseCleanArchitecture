import { Table } from "flowbite-react";
import DeleteCompanyModal from "./DeleteCompanyModal";
import EditCompanyModal from "./EditCompanyModal";

export default function AllCompanysTable () {
    return (
      <Table className="min-w-full divide-y divide-gray-200 dark:divide-gray-600">
        <Table.Head className="bg-gray-100 dark:bg-gray-700">
          <Table.HeadCell>Name</Table.HeadCell>
          <Table.HeadCell>Position</Table.HeadCell>
          <Table.HeadCell>Country</Table.HeadCell>
          <Table.HeadCell>Status</Table.HeadCell>
          <Table.HeadCell>Actions</Table.HeadCell>
        </Table.Head>
        <Table.Body className="divide-y divide-gray-200 bg-white dark:divide-gray-700 dark:bg-gray-800">
          <Table.Row className="hover:bg-gray-100 dark:hover:bg-gray-700">
            <Table.Cell className="mr-12 flex items-center space-x-6 whitespace-nowrap p-4 lg:mr-0">
              <img
                className="h-10 w-10 rounded-full"
                src="/images/Companys/neil-sims.png"
                alt="Neil Sims avatar"
              />
              <div className="text-sm font-normal text-gray-500 dark:text-gray-400">
                <div className="text-base font-semibold text-gray-900 dark:text-white">
                  Neil Sims
                </div>
                <div className="text-sm font-normal text-gray-500 dark:text-gray-400">
                  neil.sims@flowbite.com
                </div>
              </div>
            </Table.Cell>
            <Table.Cell className="whitespace-nowrap p-4 text-base font-medium text-gray-900 dark:text-white">
              Front-end developer
            </Table.Cell>
            <Table.Cell className="whitespace-nowrap p-4 text-base font-medium text-gray-900 dark:text-white">
              United States
            </Table.Cell>
            <Table.Cell className="whitespace-nowrap p-4 text-base font-normal text-gray-900 dark:text-white">
              <div className="flex items-center">
                <div className="mr-2 h-2.5 w-2.5 rounded-full bg-green-400"></div>{" "}
                Active
              </div>
            </Table.Cell>
            <Table.Cell>
              <div className="flex items-center gap-x-3 whitespace-nowrap">
                <EditCompanyModal />
                <DeleteCompanyModal />
              </div>
            </Table.Cell>
          </Table.Row>
        </Table.Body>
      </Table>
    );
  };
  
  