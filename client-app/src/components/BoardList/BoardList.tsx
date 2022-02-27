import React from "react";
import './BoardList.scss'
import { BsClipboardCheck } from "react-icons/bs";
import { BiChalkboard, BiSearch } from "react-icons/bi";
export default function Header() {
    return (
        <div className="navigation">
            <div className='navigation__search__wrapper'>
                <input className='navigation__search' type="text" />
                <BiSearch className='navigation__search__icon' />
            </div>
            <ul className="navigation__list">
                <li> <BsClipboardCheck className="task-icon" />  Meet Up</li>
                <li> <BsClipboardCheck className="task-icon" /> Reactivities</li>
                <li> <BiChalkboard className="task-icon" /> OneBlog</li>
                <li> <BsClipboardCheck className="task-icon" /> Riode</li>
            </ul>
        </div>
    )
}