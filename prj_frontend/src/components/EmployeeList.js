import React, { useState, useEffect } from 'react'
import Employee from './Employee'
import axios from 'axios';

export default function EmployeeList() {
    
    const [employeeList, setEmployeeList] = useState([])
    const [recordForEdit, setRecordForEdit] = useState(null)

    // call back function
    useEffect(() => {
        refreshEmployeeList();
    }, [])

    /* npm i -s axios */
    const employeeAPI = (url = 'https://localhost:5001/api/Employee_X01/') => {
        return {
            fetchAll: () => axios.get(url),
            create: newRecord => axios.post(url, newRecord),
            update: (id, uploadedRecord) => axios.put(url + id, uploadedRecord),
            delete: id => axios.delete(url + id)
        }
    }

    function refreshEmployeeList() {
        employeeAPI().fetchAll()
            .then(res => {
                setEmployeeList(res.data)
            })
            .catch(err => console.log(err))
    }

    const AddOrEdit = (FormData, onSuccess) => {
        
        if (FormData.get('employeeID') == "0")
        {
            employeeAPI().create(FormData)
            .then(res => {
                onSuccess();
            })
            .catch(err => console.log(err))
        }
        else{
            employeeAPI().update(FormData.get('employeeID'), FormData)
                .then(res => {
                    onSuccess();
                    refreshEmployeeList();
                })
                .catch(err => console.log(err))
        }


    }

    const showRecordDetails = data => {
        setRecordForEdit(data)
    }

    const onDelete = (e, id) => {
        e.stopPropagation();
        if (window.confirm('Are you sure to delete this record?'))
            employeeAPI().delete(id)
                .then(res => refreshEmployeeList())
                .catch(err => console.log(err))
    }

    const imageCard = data => (
        <div className="card" onClick={() => { showRecordDetails(data) }}>
            <img src={data.imageSrc} className="card-img-top rounded-circle" />
            <div className="card-body">
                <h5>{data.employeeName}</h5>
                <span>{data.occupation}</span> <br />
                <button className="btn btn-light delete-button" onClick={e => onDelete(e, parseInt(data.employeeID))}>
                    <i className="far fa-trash-alt"></i>
                </button>
            </div>
        </div>
    )

    
    return (
        <div className="row">
            <div className="col-md-12">
                <div className="container-fluid py-4">
                    <div className="container text-center">
                        <h1 className="display-4">Employee Register</h1>
                    </div>
                </div>

            </div>
            <div className="col-md-4">
                <Employee 
                AddOrEdit = {AddOrEdit} 
                recordForEdit = {recordForEdit}>
                </Employee>
            </div>
            <div className="col-md-8">
                <div>
                    <table>
                        <tbody>
                            {
                                //tr > 3 td
                                [...Array(Math.ceil(employeeList.length / 3))].map((e, i) =>
                                    <tr key={i}>
                                        <td>{imageCard(employeeList[3 * i])}</td>
                                        <td>{employeeList[3 * i + 1] ? imageCard(employeeList[3 * i + 1]) : null}</td>
                                        <td>{employeeList[3 * i + 2] ? imageCard(employeeList[3 * i + 2]) : null}</td>
                                    </tr>
                                )
                            }
                        </tbody>
                    </table> 
                </div>
            </div>
        </div>
    )
}
