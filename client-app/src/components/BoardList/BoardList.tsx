import React from "react";
import './BoardList.scss'
import { BsClipboardCheck } from "react-icons/bs";
import { BiChalkboard, BiSearch } from "react-icons/bi";
import { AiOutlineFolderAdd } from "react-icons/ai";
import CreateTaskModal from "../CreateTaskModal/CreateTaskModal";
export default function Header() {
    const [modalIsOpen, setIsOpen] = React.useState(false);
    function openModal() {
        setIsOpen(true);
    }
    return (
        <div className="navigation">
            <div className="navigation__content">
                <div className="d-flex justify-content-end">
                    <button onClick={openModal} className="change__paddword_btn create__task mt-4 me-3">
                        <AiOutlineFolderAdd className="me-1" />
                        <span>New</span>
                    </button>
                </div>
                <ul className="navigation__list">
                    <li> <BsClipboardCheck className="task-icon" />  <span>Meet Up</span></li>
                    <li> <BsClipboardCheck className="task-icon" /> <span>Reactivities</span></li>
                    <li> <BiChalkboard className="task-icon" /> <span>OneBlog</span></li>
                    <li> <BsClipboardCheck className="task-icon" /> <span>Riode</span></li>
                </ul>
            </div>

            {modalIsOpen &&
                <CreateTaskModal isOpen={modalIsOpen} setIsOpen={setIsOpen }/>
            }
        </div>
    )
}