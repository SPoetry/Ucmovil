<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class DirectoresCarrera extends Model
{

  protected $fillable = [
      'id_director', 'especialidad', 'nombre',
      'email', 'telefono', 'id_director',
  ];

  public function user(){
    return $this->belongTo(User::class, 'id_director', 'id');
  }
}
