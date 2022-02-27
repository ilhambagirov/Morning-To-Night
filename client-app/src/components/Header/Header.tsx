import React, { useEffect, useState } from 'react';
import './Header.scss'
import { BiSearch } from "react-icons/bi";
import { AiOutlineClose } from "react-icons/ai";
import HeaderAccountDropdown from './HeaderAccountDropdown';
import classnames from 'classnames';

export default function Header() {
    const [accountDropdownMode, setAccountDropdownMode] = useState(false)
    const handleAccountDropdownMode = () => {
        setAccountDropdownMode(!accountDropdownMode)
    }
    const accountPic = classnames("header__right__userphoto__holder", { 'close': accountDropdownMode })
    return (
        <div className={`custom-container`}>
            <div className='header__left'>
                <span className='header__left__logo'>M2N
                    <span className='logo__dots'></span>
                    <span className='logo__dots'></span>
                    <span className='logo__dots'></span>
                </span>
                <div className='header__left__search__wrapper'>
                    <input className='header__left__search' type="text" />
                    <BiSearch className='header__left__search__icon' />
                </div>
            </div>
            <div className='header__right'>
                <span className='header__right__username'>Ilham Baghirov</span>

                <figure onClick={handleAccountDropdownMode} className={accountPic}>
                    {
                        accountDropdownMode ?
                            <AiOutlineClose className='close__icon' />
                            : <img src={require('../../assets/erik-lucatero-d2MSDujJl2g-unsplash.jpg')} alt="" />
                    }
                </figure>

            </div>
            {
                accountDropdownMode &&
                <HeaderAccountDropdown dropdownMode={accountDropdownMode} />
            }
        </div>
    )
}