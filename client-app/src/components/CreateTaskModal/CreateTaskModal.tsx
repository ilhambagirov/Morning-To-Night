import React from "react";
import { AiOutlineClose } from "react-icons/ai";
import Modal from 'react-modal'
import './CreateTaskModal.scss'
interface Props {
    setIsOpen: (state: boolean) => void
    isOpen: boolean
}
export default function CreateTaskModal({ setIsOpen, isOpen }: Props) {

    const [predicate, setPredicate] = React.useState('');

    const customStyles = {
        content: {
            top: '50%',
            left: '50%',
            right: 'auto',
            bottom: 'auto',
            marginRight: '-50%',
            transform: 'translate(-50%, -50%)',
            border: 'none',
            backgroundColor: '#9acae5',
            padding: '15px'
        },
    };
    function closeModal() {
        setIsOpen(false);
    }
    function handleSetPredicate(value: string) {
        setPredicate(value);
    }
    return (
        <Modal
            isOpen={isOpen}
            onRequestClose={closeModal}
            style={customStyles}
            ariaHideApp={false}
        >
            <div className='createTask__Modal'>
                {
                    predicate.length === 0 ?

                        <>
                            <div className="d-flex justify-content-end"> <button className="closeModal__btn" onClick={closeModal}><AiOutlineClose /></button></div>
                            <div className="createTask__Modal__content">
                                <h4 className="mb-3">Choose type of board you want to create!</h4>
                                <div className="w100 d-flex justify-content-between">
                                    <div className="type__board me-4">
                                        <h6>Project Board</h6>
                                        <p>Real time task management with members</p>
                                        <button onClick={() => handleSetPredicate('Project')} className="create__btn">Create</button>
                                    </div>
                                    <div className="type__board">
                                        <h6>Daily Board</h6>
                                        <p>You can only create one daily board in a day</p>
                                        <button onClick={() => handleSetPredicate('Daily')} className="create__btn" >Create</button>
                                    </div>
                                </div>
                            </div>
                        </>
                        : predicate === 'Project' ?
                            <div className="project__board__create">
                                <h4 className="mb-3">Project Board</h4>
                                <form action="" className="d-flex">
                                    <div className="col-8">
                                        <div className="mb-3 row">
                                            <label className="col-4 pe-0" htmlFor="board__name">Board Name</label>
                                            <input className="col-7" id="board__name" placeholder="Board" type="text" />
                                        </div>
                                        <div className="row mb-3">
                                            <label className="col-4 pe-0" htmlFor="board__description">Description</label>
                                            <textarea className="col-7" placeholder="Description" name="boarddescription" id="board__description"></textarea>
                                        </div>
                                        <div className="row mb-3">
                                            <label className="col-4 pe-0" htmlFor="board__name">Tag</label>
                                            <input className="col-7" id="board__tag" placeholder="Tag" type="text" />
                                        </div>
                                    </div>
                                    <div className="col-4">
                                        Add Members
                                    </div>
                                </form>
                            </div>
                            :
                            <h1>Salam Daily</h1>
                }
            </div>
        </Modal>
    )
}