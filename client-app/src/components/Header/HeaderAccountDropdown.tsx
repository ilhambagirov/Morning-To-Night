import classnames from "classnames";
import './HeaderAccountDropdown.scss'
import { MdOutlineCreate } from "react-icons/md";
import React from "react";
import { BiEditAlt } from "react-icons/bi";

interface Props {
    dropdownMode: boolean
}
export default function HeaderAccountDropdown({ dropdownMode }: Props) {
    const dropdown = classnames("header__account__dropdown", { 'active': dropdownMode })
    return (
        <div className={dropdown}>
            <div className="header__account__dropdown__content">
                <div className="header__account__dropdown__content__picture__wrapper d-flex flex-column align-items-center">
                    <figure className="header__account__dropdown__content__picture">
                        <img src={require('../../assets/erik-lucatero-d2MSDujJl2g-unsplash.jpg')} alt="" />
                    </figure>
                    <button>
                        <MdOutlineCreate className="change__picture__icon" />
                        <span> Change Picture</span>
                    </button>
                </div>
                <p>Ilham Baghirov</p>
                <p>ilhambb@code.edu.az</p>
                <button className="change__paddword_btn">
                    <BiEditAlt />
                    <span>Change Password</span>
                </button>
            </div>
        </div>
    )
}