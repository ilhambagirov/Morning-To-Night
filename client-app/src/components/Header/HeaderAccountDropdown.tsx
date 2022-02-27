import classnames from "classnames";
import './HeaderAccountDropdown.scss'
import { MdOutlineCreate } from "react-icons/md";
import { RiLockPasswordLine } from "react-icons/ri";
import { FiLogOut } from "react-icons/fi";
import { FcAbout } from "react-icons/fc";
import React, { useState } from "react";
import { BiEditAlt } from "react-icons/bi";
import { ImCancelCircle } from "react-icons/im";
import { AiOutlineSave } from "react-icons/ai";

interface Props {
    dropdownMode: boolean
}
export default function HeaderAccountDropdown({ dropdownMode }: Props) {
    const [changePersonalDataMode, setChangePersonalDataMode] = useState(false);

    const handleChangePersonalDataMode = () => {
        setChangePersonalDataMode(!changePersonalDataMode)
    }
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
                {
                    !changePersonalDataMode ?
                        <div>
                            <div className="d-flex">
                                <label className="col-3" htmlFor="">Full Name</label>
                                <p className="col-9 p__input">Ilham Baghirov</p>
                            </div>
                            <div className="d-flex">
                                <label className="col-3" htmlFor="">Email</label>
                                <p className="col-9 p__input">ilhambb@code.edu.az</p>
                            </div>
                            <div className="d-flex">
                                <label className="col-3" htmlFor="">Job Title</label>
                                <p className="col-9 p__input">Software Developer</p>
                            </div>
                            <button onClick={handleChangePersonalDataMode} className="change__paddword_btn me-2">
                                <BiEditAlt className="me-1" />
                                <span>Edit</span>
                            </button>
                        </div>
                        :
                        <form action="">
                            <div className="d-flex mb-3">
                                <label className="col-3" htmlFor="">Full Name</label>
                                <input className="col-9 p__input" defaultValue='Ilham Baghirov' />
                            </div>
                            <div className="d-flex mb-3">
                                <label className="col-3" htmlFor="">Email</label>
                                <input className="col-9 p__input" defaultValue='ilhambb@code.edu.az' />
                            </div>
                            <div className="d-flex mb-3">
                                <label className="col-3" htmlFor="">Job Title</label>
                                <input className="col-9 p__input" defaultValue='Software Developer' />
                            </div>
                            <button className="change__paddword_btn me-2">
                                <AiOutlineSave className="me-1" />
                                <span>Save</span>
                            </button>
                            <button onClick={handleChangePersonalDataMode} className="change__paddword_btn">
                                <ImCancelCircle className="me-1" />
                                <span>Cancel</span>
                            </button>
                        </form>

                }

                <br />
                <div className="d-flex success__rate__wrapper">
                    <span className="col-4">Success Rate</span>
                    <div className="success__rate col-8"><span>40%</span></div>
                </div>
                <button className="change__paddword_btn mt-4">
                    <RiLockPasswordLine className="me-1" />
                    <span>Change Password</span>
                </button>
                <br />
                <button className="change__paddword_btn mt-4">
                    <FcAbout className="me-1" />
                    <span>About</span>
                </button>
                <br />
                <button className="change__paddword_btn mt-4">
                    <FiLogOut className="me-1" />
                    <span>Log out</span>
                </button>
            </div>
        </div >
    )
}