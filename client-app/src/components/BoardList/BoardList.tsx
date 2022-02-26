import React from "react";
import './BoardList.scss'
import { BsClipboardCheck } from "react-icons/bs";
import { BiChalkboard } from "react-icons/bi";
export default function Header() {
    return (
        <div className="navigation">
            <ul className="navigation__list">
                <li> <BsClipboardCheck className="task-icon" />  Meet Up</li>
                <li> <BsClipboardCheck className="task-icon" /> Reactivities</li>
                <li> <BiChalkboard className="task-icon"/> OneBlog</li>
                <li> <BsClipboardCheck className="task-icon" /> Riode</li>
            </ul>
        </div>
    )
}