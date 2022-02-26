import React, { useEffect, useState } from 'react';
import './Header.scss'
import { BiSearch } from "react-icons/bi";

export default function Header() {
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
                <figure className='header__right__userphoto__holder'>
                    <img src={require('../../assets/erik-lucatero-d2MSDujJl2g-unsplash.jpg')} alt="" />
                </figure>
            </div>
        </div>
    )
}