import React from 'react';
import './Header.scss'
import * as c from 'bootstrap-classes';

export default function Header() {

    return (
        <div className={`header ${c.d_flex}`}>
            <div className='container'>
                <div className='header__left'>
                    <span className='header__left__logo'>M2N
                        <span className='logo__dots'></span>
                        <span className='logo__dots'></span>
                        <span className='logo__dots'></span>
                    </span>
                    <input className='header__left__search' type="text" />
                </div>
                <div className='header__right'>
                    <span className='header__right__username'>Ilham Baghirov</span>
                    <figure className='header__right__userphoto__holder'>
                        <img src={require('../../assets/erik-lucatero-d2MSDujJl2g-unsplash.jpg')} alt="" />
                    </figure>
                </div>
            </div>
        </div>
    )
}