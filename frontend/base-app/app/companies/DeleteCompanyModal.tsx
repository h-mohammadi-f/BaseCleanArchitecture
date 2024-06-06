"use client"

import { Button, Modal } from "flowbite-react";
import { useState } from "react";
import { HiTrash, HiOutlineExclamationCircle } from "react-icons/hi";

export default function DeleteCompanyModal () {
    const [isOpen, setOpen] = useState(false);
  
    return (
      <>
        <Button color="failure" onClick={() => setOpen(true)}>
          <div className="flex items-center gap-x-2">
            <HiTrash className="text-lg" />
            Delete Company
          </div>
        </Button>
        <Modal onClose={() => setOpen(false)} show={isOpen} size="md">
          <Modal.Header className="px-6 pt-6 pb-0">
            <span className="sr-only">Delete Company</span>
          </Modal.Header>
          <Modal.Body className="px-6 pt-0 pb-6">
            <div className="flex flex-col items-center gap-y-6 text-center">
              <HiOutlineExclamationCircle className="text-7xl text-red-500" />
              <p className="text-xl text-gray-500">
                Are you sure you want to delete this Company?
              </p>
              <div className="flex items-center gap-x-3">
                <Button color="failure" onClick={() => setOpen(false)}>
                  Yes, I'm sure
                </Button>
                <Button color="gray" onClick={() => setOpen(false)}>
                  No, cancel
                </Button>
              </div>
            </div>
          </Modal.Body>
        </Modal>
      </>
    );
  };
  
 