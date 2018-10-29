<?php

namespace App;

use Illuminate\Database\Eloquent\Model;

class RamosActuale extends Model
{
  protected $fillable = [
      'id_ramo', 'id_alumno',
  ];
  public function alumno(){
    return $this->belongsTo(Alumno::class, 'id_alumno', 'id');
  }
  public function versionramo(){
    return $this->belongsTo(VersionRamo::class, 'id_ramo', 'id_ramo');
  }
}
